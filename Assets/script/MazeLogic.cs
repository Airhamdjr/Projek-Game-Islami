using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapLocation
{
    public int x;
    public int z;


    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}
public class MazeLogic : MonoBehaviour
{

    public int width = 30; // x length
    public int depth = 30; // y length
    public int scale = 6;
    public GameObject Character;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public GameObject Enemy;
    public int EnemyCount = 3;
    public int RoomCount = 3;
    public int RoomMinSize = 6;
    public int RoomMaxSize = 10;
    public NavMeshSurface surface;
    public List<GameObject> Cube; // maze wall
    public GameObject Atap;
    public GameObject pintu;

    public byte[,] map;
    public byte[,] occupiedMap;
    public List<MapLocation> RoomLocations;

    // Start is called before the first frame update
    void Start()
    {
        InitialiseMap();
        GenerateMaps();
        AddRooms(RoomCount, RoomMinSize, RoomMaxSize);
        DrawMaps();
        PlaceCharacter();
        occupiedMap = new byte[width, depth];
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                occupiedMap[x, z] = 0;
            }

        PlaceEnemy();
        PlaceNPCs();
        surface.BuildNavMesh();

        //PlaceAtap();

        //instantiate = fungsi dimana kita memanggil gameObject
        //Quaternion.Identity = mengatur object tetep sesuai default

    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitialiseMap()
    {
        map = new byte[width, depth];
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                map[x, z] = 1;
            }
    }

    public virtual void GenerateMaps()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (Random.Range(0, 100) < 50)
                    map[x, z] = 0;
            }
    }

    void DrawMaps()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = Instantiate(Cube[Random.Range(0, Cube.Count)], pos, Quaternion.identity);

                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                }
                else if (map[x, z] == 0 || map[x, z] == 2)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject roof = Instantiate(Atap, pos, Quaternion.identity);
                    roof.transform.localScale = new Vector3(scale, scale, scale);
                    roof.transform.position = pos;
                    //PlaceDoorBeforeRoom(x, z);
                }
            }
    }
    void PlaceDoorBeforeRoom(int x, int z)
    {
        // Cek apakah lokasi ini adalah lorong
        if (map[x, z] == 0)
        {
            // Cek apakah lokasi di sepanjang sumbu z
            if (x > 0 && x < width - 1 && z > 0 && z < depth - 1)
            {
                // Cek apakah lokasi di sepanjang sumbu x adalah ruangan
                if (map[x - 1, z] == 2 || map[x + 1, z] == 2)
                {
                    // Tambahkan game object pintu di depan lorong
                    Vector3 doorPos = new Vector3(x * scale, 0, z * scale);
                    GameObject door = Instantiate(pintu, doorPos, Quaternion.identity);
                    door.transform.localScale = new Vector3(scale, scale, scale);
                    Debug.Log("Door placed before room at " + doorPos);
                }
            }
        }
    }

    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x - 1, z] == 0) count++;
        if (map[x + 1, z] == 0) count++;
        if (map[x, z + 1] == 0) count++;
        if (map[x, z - 1] == 0) count++;
        return count;
    }
    public virtual void PlaceCharacter()
    {
        bool PlayerSet = false;
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int x = Random.Range(0, width);
                int z = Random.Range(0, depth);
                if (map[x, z] == 0 && !PlayerSet)
                {
                    Debug.Log("placing Character");
                    PlayerSet = true;
                    Character.transform.position = new Vector3(x * scale, 0, z * scale);
                }
                else if (PlayerSet)
                {
                    Debug.Log("alredy Placing Character");
                    return;
                }
            }
        }
    }
    public virtual void PlaceEnemy()
    {
        int EnemySet = 0;

        foreach (var roomLocation in RoomLocations)
        {
            int x = roomLocation.x;
            int z = roomLocation.z;

            if (map[x, z] == 2 && EnemySet < EnemyCount)
            {
                Debug.Log("Placing Enemy");

                // Adjust position within the room
                Vector3 enemyPos = new Vector3(x * scale + Random.Range(-scale / 2, scale / 2), 0, z * scale + Random.Range(-scale / 2, scale / 2));

                Instantiate(Enemy, enemyPos, Quaternion.identity);
                EnemySet++;
            }

            // Jika sudah menempatkan semua Enemy, keluar dari loop
            if (EnemySet == EnemyCount)
            {
                Debug.Log("Already placing all the enemy");
                return;
            }
        }
    }

    public virtual void PlaceNPCs()
    {
        int NPCSet = 0;

        foreach (var roomLocation in RoomLocations)
        {
            int x = roomLocation.x;
            int z = roomLocation.z;

            if (map[x, z] == 2 && NPCSet < 4)
            {
                Debug.Log("Placing NPC");

                // Adjust position within the room
                Vector3 npcPos = new Vector3(x * scale + Random.Range(-scale / 2, scale / 2), 0.5f, z * scale + Random.Range(-scale / 2, scale / 2));

                // Tambahkan NPC ke dalam ruangan
                // Gunakan nilai NPCSet untuk memilih objek NPC yang sesuai (NPC1, NPC2, dll.)
                GameObject npcPrefab = null;

                switch (NPCSet)
                {
                    case 0:
                        npcPrefab = NPC1;
                        break;
                    case 1:
                        npcPrefab = NPC2;
                        break;
                    case 2:
                        npcPrefab = NPC3;
                        break;
                    case 3:
                        npcPrefab = NPC4;
                        break;
                }

                if (npcPrefab != null)
                {
                    // Pastikan lokasi belum diambil oleh Enemy atau NPC sebelumnya
                    if (map[x, z] == 2 && !IsPositionOccupied(x, z))
                    {
                        // Pindahkan objek NPC yang sudah ada ke posisi baru
                        npcPrefab.transform.position = npcPos;
                        NPCSet++;
                    }
                }
            }

            // Jika sudah menempatkan semua NPC, keluar dari loop
            if (NPCSet == 4)
            {
                Debug.Log("Already placing all the NPCs");
                return;
            }
        }
    }


    bool IsPositionOccupied(int x, int z)
    {
        return occupiedMap[x, z] == 1;
    }




    public virtual void AddRooms(int count, int minSize, int maxSize)
    {
        RoomLocations = new List<MapLocation>();

        for (int c = 0; c < count; c++)
        {
            int startX = Random.Range(3, width - 3);
            int startZ = Random.Range(3, depth - 3);
            int roomWidth = Random.Range(minSize, maxSize);
            int roomDepth = Random.Range(minSize, maxSize);

            // Pemeriksaan apakah ruangan baru akan berdekatan dengan yang sudah ada
            bool roomOverlap = false;
            for (int x = startX - 1; x < startX + roomWidth + 1; x++)
            {
                for (int z = startZ - 1; z < startZ + roomDepth + 1; z++)
                {
                    if (x >= 0 && x < width && z >= 0 && z < depth && map[x, z] == 2)
                    {
                        // Ruangan baru akan berdekatan dengan yang sudah ada
                        roomOverlap = true;
                        break;
                    }
                }
                if (roomOverlap)
                    break;
            }

            // Jika ruangan tidak berdekatan, tandai ruangan baru
            if (!roomOverlap)
            {
                for (int x = startX; x < width && x < startX + roomWidth; x++)
                {
                    for (int z = startZ; z < depth && z < startZ + roomDepth; z++)
                    {
                        map[x, z] = 2;
                    }
                }

                // Simpan lokasi ruangan ke dalam RoomLocations
                RoomLocations.Add(new MapLocation(startX + roomWidth / 2, startZ + roomDepth / 2));
            }
            else
            {
                // Coba lagi untuk ruangan baru
                c--;
            }
        }
    }







}