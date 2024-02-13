using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SaveData;

public enum MoveDirection
{
    LeftUp = 0,
    Up = 1,
    RightUp = 2,
    Right = 3,
    RightDown = 4,
    Down = 5,
    LeftDown = 6,
    Left = 7,
}
public class Support : MonoBehaviour
{
    public struct Mouse
    {
        /// <summary>
        /// 레이어 명으로 마우스 위치 오브젝트 찾기
        /// </summary>
        /// <param name="layerName">레이어 이름</param>
        /// <returns>오브젝트</returns>
        public static GameObject GetMouse_PointToLayer(string layerName)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit;

            hit = Physics.RaycastAll(ray, 100f);
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.layer == LayerMask.NameToLayer(layerName))
                {
                    return hit[i].collider.gameObject;
                }
            }
            return null;
        }

        /// <summary>
        /// 마우스 '로컬' 좌표 구하기
        /// </summary>
        /// <returns>좌표</returns>
        public static Vector3 GetMouse_LocalPoint()
        {
            Vector3 point = Input.mousePosition;

            int width = Screen.width; // x
            int height = Screen.height; // y

            Vector3 MidPoint = new Vector3(width, height, 0);

            Vector3 MousePoint = point - (MidPoint / 2);

            return MousePoint;
        }

        /// <summary>
        /// 마우스 '월드' 좌표 구하기
        /// </summary>
        /// <returns>좌표</returns>
        public static Vector3 GetMouse_WorldPoint()
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        }
    }
    public struct Vector
    {
        /// <summary>
        ///  벡터 값 반올림
        /// </summary>
        /// <param name="vector">반올림 할 벡터</param>
        /// <returns>반올림 된 벡터</returns>
        public static Vector3 Get_RoundVector(Vector3 vector) { return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z)); }
        /// <summary>
        /// 이동 좌표 얻기
        /// </summary>
        /// <param name="direction">이동 할 방향</param>
        /// <returns>이동할 방향 좌표</returns>
        public static Vector3 Get_MoveDirection(MoveDirection direction)
        {
            int[] X = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] Z = { 1, 1, 1, 0, -1, -1, -1, 0 };

            return new Vector3(X[(int)direction], 0, Z[(int)direction]);
        }
        /// <summary>
        /// 방향 벡터 구하기
        /// </summary>
        public static Quaternion Get_DirectionVector(Vector3 start, Vector3 end)
        {
            Vector3 dir = end - start;
            dir.y = 0f;

            Quaternion rotation = Quaternion.LookRotation(dir.normalized);
            return rotation;
        }
    }
    public struct Math
    {
        /// <summary>
        /// 사거리 계산
        /// </summary>
        /// <param name="start">시작 위치</param>
        /// <param name="end">끝 위치</param>
        /// <returns>시작과 끝 사이의 거리</returns>
        public static int Get_Distance(Vector3 start, Vector3 end)
        {
            Vector3 round = Vector.Get_RoundVector(start) - Vector.Get_RoundVector(end);

            int X = (int)round.x, Z = (int)round.z;

            if (X < 0) X *= -1;
            if (Z < 0) Z *= -1;

            if (X > Z) return X;
            if (X < Z) return Z;
            return X;
        }
        /// <summary>
        /// 이동할 좌표 찾기
        /// </summary>
        /// <param name="start">시작 위치</param>
        /// <param name="end">끝 위치</param>
        /// <returns>시작에서 끝으로 향하는 좌표 인트값</returns>
        public static int Get_MoveDirection_int(Vector3 start, Vector3 end)
        {
            Vector3 round = Vector.Get_RoundVector(start) - Support.Vector.Get_RoundVector(end);
            Vector3 check = new Vector3(0, 0, 0);

            if (round.x == 0) check.x = 0;
            else if (round.x > 0) check.x = 1;
            else if (round.x < 0) check.x = -1;

            if (round.z == 0) check.z = 0;
            else if (round.z > 0) check.z = 1;
            else if (round.z < 0) check.z = -1;

            check *= -1;

            for (int i = 0; i < 8; i++)
            {
                Vector3 dir = Vector.Get_MoveDirection((MoveDirection)i);

                if (check.x - dir.x == 0 && check.z - dir.z == 0)
                    return i;
            }

            return 8;
        }
        /// <summary>
        /// 이동할 좌표 찾기
        /// </summary>
        /// <param name="start">시작 위치</param>
        /// <param name="end">끝 위치</param>
        /// <returns>시작에서 끝으로 향하는 좌표 좌표값</returns>
        public static Vector3 Get_MoveDirection_Vector3(Vector3 start, Vector3 end)
        {
            Vector3 round = Vector.Get_RoundVector(start) - Vector.Get_RoundVector(end);
            Vector3 check = new Vector3(0, 0, 0);

            if (round.x == 0) check.x = 0;
            else if (round.x > 0) check.x = 1;
            else if (round.x < 0) check.x = -1;

            if (round.z == 0) check.z = 0;
            else if (round.z > 0) check.z = 1;
            else if (round.z < 0) check.z = -1;

            check *= -1;

            for (int i = 0; i < 8; i++)
            {
                Vector3 dir = Vector.Get_MoveDirection((MoveDirection)i);

                if (check.x - dir.x == 0 && check.z - dir.z == 0)
                    return Vector.Get_RoundVector(start) + dir;
            }

            return new Vector3(0, 1, 0);
        }
        /// <summary>
        /// 방어 계산
        /// </summary>
        /// <param name="damage">피해량</param>
        /// <param name="defense">방어력</param>
        /// <returns>방어 계산된 피해</returns>
        public static float Get_DefenseRate(float damage, float defense)
        {
            float DefenseRate = defense / (defense + SaveValue.DefenseConstant);

            return damage * (1 - DefenseRate);
        }
        /// <summary>
        /// 확률의 성공 실패 계산
        /// </summary>
        /// <param name="chance">확률</param>
        /// <returns>성공 시 true, 실패 시 false</returns>
        public static bool Get_ChanceValue(float chance)
        {
            if (chance >= 100)
                return true;

            float value = Random.Range(0, 100);

            if (value > chance)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 이동 값 더하기
        /// </summary>
        /// <param name="direction">이동 값</param>
        /// <param name="addValue">더할 값</param>
        /// <returns>더한 값</returns>
        public static int Add_MoveDirection(int direction, int addValue)
        {
            if (direction < 0 || direction >= 8)
                return 8;

            int backDirection = direction + addValue;

            if (backDirection < 0) backDirection += 8;
            if (direction >= 8) backDirection -= 8;

            return backDirection;
        }
        /// <summary>
        /// 벨류값 계산
        /// </summary>
        /// <param name="current">현재 값</param>
        /// <param name="max">최대 값</param>
        /// <param name="maxValue">비율 최대 값</param>
        /// <returns></returns>
        public static float Get_ValueRate(float current, float max, float maxValue)
        {
            float ret = (maxValue / max) * current;

            if (ret < 0) ret = 0;
            if (ret > maxValue) ret = maxValue;

            return ret;
        }
        /// <summary>
        /// 현재 업글 비용
        /// </summary>
        /// <param name="upgrade">시작 업글 비용</param>
        /// <param name="upRate">오르는 값</param>
        /// <param name="level">현재 레벨</param>
        /// <returns></returns>
        public static float Get_UpgradeRate(float upgrade,float upRate,float level)
        {
            return upgrade + (upRate * level);
        }
        /// <summary>
        /// 업글한 가격 전체
        /// </summary>
        /// <param name="upgrade">시작 업글 비용</param>
        /// <param name="upRate">오르는 값</param>
        /// <param name="level">현재 레벨</param>
        /// <returns></returns>
        public static float Get_UpgradeAllPrice(float upgrade, float upRate, float level)
        {
            return (upgrade * level) + ((int)(level / 2) * (upRate * level)) - (level % 2 == 0 ? upRate * (int)(level / 2) : 0);
        }
        public static float Math_MagicDamge(float magic, float rate)
        {
            return rate * (magic / 100);
        }
    }
    public struct Unit
    {
        /// <summary>
        /// 랜덤한 이름 얻기
        /// </summary>
        /// <returns>랜덤한 이름</returns>
        public static string GetRandomName()
        {
            string name = SaveValue.Name_Second[Random.Range(0, SaveValue.Name_Second.Length)] + " " + SaveValue.Name_First[Random.Range(0, SaveValue.Name_First.Length)];
            return name;
        }

        /// <summary>
        /// 투사체 날리기
        /// </summary>
        /// <param name="start">시작 위치</param>
        /// <param name="end">끝 위치</param>
        /// <param name="projectile">투사체</param>
        /// <param name="power">점프 파워</param>
        /// <param name="delay">걸리는 시간</param>
        public static void AttackProjectile(Vector3 start, Vector3 end, GameObject projectile, float power, float delay)
        {
            if (projectile == null)
                return;
            
            Vector3 Vector = Support.Vector.Get_RoundVector(end);
            if (Vector.y != 0) return;

            GameObject pro = Instantiate(projectile, start, Quaternion.identity);
            
            pro.transform.LookAt(end);
            pro.transform.DOJump(end, power, 1, delay).SetEase(Ease.Linear);

            Destroy(pro, delay + 0.03f);
        }
        public static void AttackProjectile(Vector3 start, Vector3 end, GameObject projectile, float power, float delay, Ease ease)
        {
            if (projectile == null)
                return;

            Vector3 Vector = Support.Vector.Get_RoundVector(end);
            if (Vector.y != 0) return;

            GameObject pro = Instantiate(projectile, start, Quaternion.identity);

            pro.transform.LookAt(end);
            pro.transform.DOJump(end, power, 1, delay).SetEase(ease);

            Destroy(pro, delay + 0.02f);
        }
        public static void AttackProjectile(Vector3 start, Vector3 end, GameObject projectile, float power, float delay, float startDelay)
        {
            if (projectile == null)
                return;

            CoroutineHandler.Start_Coroutine(projectDelay(start, end, projectile, power, delay, startDelay));
        }
        public static IEnumerator projectDelay(Vector3 start, Vector3 end, GameObject projectile, float power, float delay, float startDelay)
        {
            yield return new WaitForSeconds(startDelay);
            AttackProjectile(start,end, projectile, power, delay);
            yield return null;
        }

    }
}
