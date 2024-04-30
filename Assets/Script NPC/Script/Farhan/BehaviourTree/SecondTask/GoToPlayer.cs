using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class GoToPlayer : Node
{
    // Start is called before the first frame update
    private static int _playerLayerMask = 1 << 8;

    private Transform _transform;
    private PlayerData _playerData;
    private GameObject _player;
    private GameObject _npc;
    private Animator _animator;

    public float npcWalkingSpeed;

    float nilai;
    float waktu;
    float pengalaman;

    // Penentuan Bobot tiap alternatif
    float bobotNilai = 0.5f;
    float bobotWaktu = 0.3f;
    float bobotPengalaman = 0.2f;

    // inisiasi alternatif 
    float Alt1;
    float Alt2;
    float Alt3;
    float AltBehaviour;

    float alternatif11 = 0, alternatif12 = 0, alternatif13 = 0;
    float alternatif21 = 0, alternatif22 = 0, alternatif23 = 0;
    float alternatif31 = 0, alternatif32 = 0, alternatif33 = 0;

    // Inisiasi Normalisasi Nilai
    float NormalisasiNilai11, NormalisasiNilai12, NormalisasiNilai13;
    float NormalisasiNilai21, NormalisasiNilai22, NormalisasiNilai23;
    float NormalisasiNilai31, NormalisasiNilai32, NormalisasiNilai33;

    // Inisiasi Perangkingan
    float perangkingan11, perangkingan12, perangkingan13;
    float perangkingan21, perangkingan22, perangkingan23;
    float perangkingan31, perangkingan32, perangkingan33;

    public GoToPlayer(PlayerData playerData, GameObject player, GameObject npc, Transform transform)
    {
        _playerData = playerData;
        _player = player;
        _npc = npc;
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    void awake()
    {
        _playerData = _player.GetComponent<PlayerData>();
    }
    void PerhitunganDSS()
    {
        // Pengambilan Data dari Player
        nilai = _playerData.Nilai;
        waktu = _playerData.Waktu;
        pengalaman = _playerData.Pengalaman;

        // Matriks keputusan
        // Kriteria 1 (Nilai)
        if (nilai > 8)
        {
            alternatif11 = 3;
            alternatif21 = 1;
            alternatif31 = 1;
        }
        else if (nilai > 4 && nilai <= 8)
        {
            alternatif11 = 1;
            alternatif21 = 3;
            alternatif31 = 1;
        }
        else if (nilai >= 0 && nilai <= 4)
        {
            alternatif11 = 1;
            alternatif21 = 1;
            alternatif31 = 3;
        }

        // Kriteria 2 (Waktu)
        if (waktu <= 20)
        {
            alternatif12 = 3;
            alternatif22 = 1;
            alternatif32 = 1;
        }
        else if (waktu > 20 && waktu <= 40)
        {
            alternatif12 = 1;
            alternatif22 = 3;
            alternatif32 = 1;
        }
        else if (waktu > 40 && waktu <= 60)
        {
            alternatif12 = 1;
            alternatif22 = 1;
            alternatif32 = 3;
        }

        // Kriteria 3 (Pengalaman)
        // pernah = 1, kurang = 2, tidak = 3
        if (pengalaman == 1)
        {
            alternatif13 = 3;
            alternatif23 = 1;
            alternatif33 = 1;
        }
        else if (pengalaman == 2)
        {
            alternatif13 = 1;
            alternatif23 = 3;
            alternatif33 = 1;
        }
        else if (pengalaman == 3)
        {
            alternatif13 = 1;
            alternatif23 = 1;
            alternatif33 = 3;
        }

        // Normalisasi
        NormalisasiNilai11 = alternatif11 / 3;
        NormalisasiNilai21 = alternatif21 / 3;
        NormalisasiNilai31 = alternatif31 / 3;

        NormalisasiNilai12 = alternatif12 / 3;
        NormalisasiNilai22 = alternatif22 / 3;
        NormalisasiNilai32 = alternatif32 / 3;

        NormalisasiNilai13 = alternatif13 / 3;
        NormalisasiNilai23 = alternatif23 / 3;
        NormalisasiNilai33 = alternatif33 / 3;

        // Perangkingan 
        perangkingan11 = NormalisasiNilai11 * bobotNilai;
        perangkingan21 = NormalisasiNilai21 * bobotNilai;
        perangkingan31 = NormalisasiNilai31 * bobotNilai;

        perangkingan12 = NormalisasiNilai12 * bobotWaktu;
        perangkingan22 = NormalisasiNilai22 * bobotWaktu;
        perangkingan32 = NormalisasiNilai32 * bobotWaktu;

        perangkingan13 = NormalisasiNilai13 * bobotPengalaman;
        perangkingan23 = NormalisasiNilai23 * bobotPengalaman;
        perangkingan33 = NormalisasiNilai33 * bobotPengalaman;

        Alt1 = perangkingan11 + perangkingan12 + perangkingan13;
        Alt2 = perangkingan21 + perangkingan22 + perangkingan23;
        Alt3 = perangkingan31 + perangkingan32 + perangkingan33;

        AltBehaviour = Mathf.Max(Alt1, Alt2, Alt3);
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, _player.transform.position) > 3f && Vector3.Distance(_transform.position, _player.transform.position) < 10f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, _player.transform.position, ActionBT.npcWalkingSpeed * Time.deltaTime);
            _transform.LookAt(_player.transform.position);

            _animator.SetBool("Walking", true);
            _animator.SetBool("Running", false);
            _animator.SetBool("Talking", false);
            _animator.SetBool("Arguing", false);
            _animator.SetBool("Yelling", false);

            Debug.Log("Menghampiri Player");

            state = NodeState.RUNNING;
            return state;
        }
        else if (Vector3.Distance(_transform.position, _player.transform.position) < 3f)
        {
            _animator.SetBool("Walking", false);
            _animator.SetBool("Running", false);

            if (AltBehaviour == Alt1)
            {
                _animator.SetBool("Talking", true);

                Debug.Log("HALLO " + _player + " Perkenalkan Nama Saya " + _npc);
                Debug.Log("Nilai = " + nilai + " Soal Terjawab Benar");
                Debug.Log("Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal");
                Debug.Log("Pengalaman = " + pengalaman + " (Pernah Belajar dan Paham)");
                Debug.Log("Greet");
                PerhitunganDSS();

                state = NodeState.RUNNING;
                return state;
            }
            else if (AltBehaviour == Alt2)
            {
                _animator.SetBool("Arguing", true);

                Debug.Log("HALLO " + _player + " Perkenalkan Nama Saya " + _npc);
                Debug.Log("Nilai = " + nilai + " Soal Terjawab Benar");
                Debug.Log("Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal");
                Debug.Log("Pengalaman = " + pengalaman + " (Pernah Belajar dan Paham)");
                Debug.Log("Approach");
                PerhitunganDSS();

                state = NodeState.RUNNING;
                return state;
            }
            else if (AltBehaviour == Alt3)
            {
                _animator.SetBool("Yelling", true);

                Debug.Log("HALLO " + _player + " Perkenalkan Nama Saya " + _npc);
                Debug.Log("Nilai = " + nilai + " Soal Terjawab Benar");
                Debug.Log("Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal");
                Debug.Log("Pengalaman = " + pengalaman + " (Pernah Belajar dan Paham)");
                Debug.Log("Follow");
                PerhitunganDSS();

                state = NodeState.RUNNING;
                return state;
            }

        }
        else if (Vector3.Distance(_transform.position, _player.transform.position) > 10f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, _player.transform.position, ActionBT.npcRunningSpeed * Time.deltaTime);
            _transform.LookAt(_player.transform.position);

            _animator.SetBool("Running", true);
            _animator.SetBool("Walking", false);
            _animator.SetBool("Talking", false);
            _animator.SetBool("Arguing", false);
            _animator.SetBool("Yelling", false);

            Debug.Log("Player terlalu Jauh");

            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
