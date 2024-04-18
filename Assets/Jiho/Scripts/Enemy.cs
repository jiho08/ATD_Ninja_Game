using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int _wayPointCount; // 이동 경로 개수
    Transform[] _wayPoints; // 이동 경로 정보
    int _currentIndex = 0; // 현재 목표 지점 인덱스
    UnitMovement _movement2D; // 오브젝트 이동 제어
    public void Setup(Transform[] _wayPoints)
    {
        _movement2D = GetComponent<UnitMovement>();

        // 적 이동 경로 _wayPoints 정보 설정
        _wayPointCount = _wayPoints.Length;
        this._wayPoints = new Transform[_wayPointCount];
        this._wayPoints = _wayPoints;

        // 적의 위치를 첫 번째 _wayPoint 위치로 설정
        transform.position = _wayPoints[_currentIndex].position;

        // 적 이동 / 목표 지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");
    }
    private IEnumerator OnMove()
    {
        // 다음 이동 방향 설정
        NextMoveTo();
        while (true)
        {
            // 적 오브젝트 회전
            transform.Rotate(Vector3.forward * 10);
            
            // 적의 현재 위치와 목표 위치의 거리가 0.02 * _movement2D.MoveSpeed보다 작을 때 if 조건문 실행
            // Tip : _movement2D.MoveSpeed를 곱해주는 이유는 속도가 빠르면 한 프레임에 0.02 보다 크게 움직이기 때문에
            // if 조건문에 걸리지 않고 경로로 탈주하는 오브젝트가 발생할 수 있다.
            if (Vector3.Distance(transform.position, _wayPoints[_currentIndex].position) < 0.02f * _movement2D._MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }
    private void NextMoveTo()
    {
        // 아직 이동할 _wayPoints가 남아있다면
        if (_currentIndex < _wayPointCount - 1)
        {
            // 적의 위치를 정확하게 목표 위치로 설정
            transform.position = _wayPoints[_currentIndex].position;
            // 이동 방향 설정 => 다음 목표 지점(_wayPoints)
            _currentIndex++;
            Vector3 _direction = (_wayPoints[_currentIndex].position - transform.position).normalized;
            _movement2D.MoveTo(_direction);
        }
        else // 현재 위치가 마지막 _wayPoints 라면
        {
            // 적 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
