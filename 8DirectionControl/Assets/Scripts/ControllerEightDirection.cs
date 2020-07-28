using UnityEngine;

namespace KID
{
    public class ControllerEightDirection : MonoBehaviour
    {
        [Header("移動速度"), Range(0, 100)]
        public float speed = 10;

        /// <summary>
        /// 剛體
        /// </summary>
        private Rigidbody rig;

        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移動：八個方向
        /// </summary>
        private void Move()
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(h, 0, v);

            // 如果 按下移動鍵 角度 = 角度.插值(原本角度，要前往的方向角度，插值百分比)
            if (h != 0 || v != 0) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

            // 剛體.移動(原本座標 + 輸入的移動量 * 速度 * 1 / 60)
            rig.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
        }
    }
}
