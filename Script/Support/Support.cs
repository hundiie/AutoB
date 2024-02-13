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
        /// ���̾� ������ ���콺 ��ġ ������Ʈ ã��
        /// </summary>
        /// <param name="layerName">���̾� �̸�</param>
        /// <returns>������Ʈ</returns>
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
        /// ���콺 '����' ��ǥ ���ϱ�
        /// </summary>
        /// <returns>��ǥ</returns>
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
        /// ���콺 '����' ��ǥ ���ϱ�
        /// </summary>
        /// <returns>��ǥ</returns>
        public static Vector3 GetMouse_WorldPoint()
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        }
    }
    public struct Vector
    {
        /// <summary>
        ///  ���� �� �ݿø�
        /// </summary>
        /// <param name="vector">�ݿø� �� ����</param>
        /// <returns>�ݿø� �� ����</returns>
        public static Vector3 Get_RoundVector(Vector3 vector) { return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z)); }
        /// <summary>
        /// �̵� ��ǥ ���
        /// </summary>
        /// <param name="direction">�̵� �� ����</param>
        /// <returns>�̵��� ���� ��ǥ</returns>
        public static Vector3 Get_MoveDirection(MoveDirection direction)
        {
            int[] X = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] Z = { 1, 1, 1, 0, -1, -1, -1, 0 };

            return new Vector3(X[(int)direction], 0, Z[(int)direction]);
        }
        /// <summary>
        /// ���� ���� ���ϱ�
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
        /// ��Ÿ� ���
        /// </summary>
        /// <param name="start">���� ��ġ</param>
        /// <param name="end">�� ��ġ</param>
        /// <returns>���۰� �� ������ �Ÿ�</returns>
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
        /// �̵��� ��ǥ ã��
        /// </summary>
        /// <param name="start">���� ��ġ</param>
        /// <param name="end">�� ��ġ</param>
        /// <returns>���ۿ��� ������ ���ϴ� ��ǥ ��Ʈ��</returns>
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
        /// �̵��� ��ǥ ã��
        /// </summary>
        /// <param name="start">���� ��ġ</param>
        /// <param name="end">�� ��ġ</param>
        /// <returns>���ۿ��� ������ ���ϴ� ��ǥ ��ǥ��</returns>
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
        /// ��� ���
        /// </summary>
        /// <param name="damage">���ط�</param>
        /// <param name="defense">����</param>
        /// <returns>��� ���� ����</returns>
        public static float Get_DefenseRate(float damage, float defense)
        {
            float DefenseRate = defense / (defense + SaveValue.DefenseConstant);

            return damage * (1 - DefenseRate);
        }
        /// <summary>
        /// Ȯ���� ���� ���� ���
        /// </summary>
        /// <param name="chance">Ȯ��</param>
        /// <returns>���� �� true, ���� �� false</returns>
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
        /// �̵� �� ���ϱ�
        /// </summary>
        /// <param name="direction">�̵� ��</param>
        /// <param name="addValue">���� ��</param>
        /// <returns>���� ��</returns>
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
        /// ������ ���
        /// </summary>
        /// <param name="current">���� ��</param>
        /// <param name="max">�ִ� ��</param>
        /// <param name="maxValue">���� �ִ� ��</param>
        /// <returns></returns>
        public static float Get_ValueRate(float current, float max, float maxValue)
        {
            float ret = (maxValue / max) * current;

            if (ret < 0) ret = 0;
            if (ret > maxValue) ret = maxValue;

            return ret;
        }
        /// <summary>
        /// ���� ���� ���
        /// </summary>
        /// <param name="upgrade">���� ���� ���</param>
        /// <param name="upRate">������ ��</param>
        /// <param name="level">���� ����</param>
        /// <returns></returns>
        public static float Get_UpgradeRate(float upgrade,float upRate,float level)
        {
            return upgrade + (upRate * level);
        }
        /// <summary>
        /// ������ ���� ��ü
        /// </summary>
        /// <param name="upgrade">���� ���� ���</param>
        /// <param name="upRate">������ ��</param>
        /// <param name="level">���� ����</param>
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
        /// ������ �̸� ���
        /// </summary>
        /// <returns>������ �̸�</returns>
        public static string GetRandomName()
        {
            string name = SaveValue.Name_Second[Random.Range(0, SaveValue.Name_Second.Length)] + " " + SaveValue.Name_First[Random.Range(0, SaveValue.Name_First.Length)];
            return name;
        }

        /// <summary>
        /// ����ü ������
        /// </summary>
        /// <param name="start">���� ��ġ</param>
        /// <param name="end">�� ��ġ</param>
        /// <param name="projectile">����ü</param>
        /// <param name="power">���� �Ŀ�</param>
        /// <param name="delay">�ɸ��� �ð�</param>
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
