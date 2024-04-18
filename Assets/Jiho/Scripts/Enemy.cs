using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int _wayPointCount; // �̵� ��� ����
    Transform[] _wayPoints; // �̵� ��� ����
    int _currentIndex = 0; // ���� ��ǥ ���� �ε���
    UnitMovement _movement2D; // ������Ʈ �̵� ����
    public void Setup(Transform[] _wayPoints)
    {
        _movement2D = GetComponent<UnitMovement>();

        // �� �̵� ��� _wayPoints ���� ����
        _wayPointCount = _wayPoints.Length;
        this._wayPoints = new Transform[_wayPointCount];
        this._wayPoints = _wayPoints;

        // ���� ��ġ�� ù ��° _wayPoint ��ġ�� ����
        transform.position = _wayPoints[_currentIndex].position;

        // �� �̵� / ��ǥ ���� ���� �ڷ�ƾ �Լ� ����
        StartCoroutine("OnMove");
    }
    private IEnumerator OnMove()
    {
        // ���� �̵� ���� ����
        NextMoveTo();
        while (true)
        {
            // �� ������Ʈ ȸ��
            transform.Rotate(Vector3.forward * 10);
            
            // ���� ���� ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.02 * _movement2D.MoveSpeed���� ���� �� if ���ǹ� ����
            // Tip : _movement2D.MoveSpeed�� �����ִ� ������ �ӵ��� ������ �� �����ӿ� 0.02 ���� ũ�� �����̱� ������
            // if ���ǹ��� �ɸ��� �ʰ� ��η� Ż���ϴ� ������Ʈ�� �߻��� �� �ִ�.
            if (Vector3.Distance(transform.position, _wayPoints[_currentIndex].position) < 0.02f * _movement2D._MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }
    private void NextMoveTo()
    {
        // ���� �̵��� _wayPoints�� �����ִٸ�
        if (_currentIndex < _wayPointCount - 1)
        {
            // ���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
            transform.position = _wayPoints[_currentIndex].position;
            // �̵� ���� ���� => ���� ��ǥ ����(_wayPoints)
            _currentIndex++;
            Vector3 _direction = (_wayPoints[_currentIndex].position - transform.position).normalized;
            _movement2D.MoveTo(_direction);
        }
        else // ���� ��ġ�� ������ _wayPoints ���
        {
            // �� ������Ʈ ����
            Destroy(gameObject);
        }
    }
}
