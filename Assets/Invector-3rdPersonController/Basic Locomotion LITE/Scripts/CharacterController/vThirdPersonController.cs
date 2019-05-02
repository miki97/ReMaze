using UnityEngine;
using System.Collections;

namespace Invector.CharacterController
{
    public class vThirdPersonController : vThirdPersonAnimator
    {
        public AudioClip CoinSound = null;
        public AudioClip JumpSound = null;
        protected virtual void Start()
        {
#if !UNITY_EDITOR
                Cursor.visible = false;
#endif
            //mAudioSource = GetComponent<AudioSource>();
        }

        public virtual void Sprint(bool value)
        {                                   
            isSprinting = value;            
        }

        public virtual void Strafe()
        {
            if (locomotionType == LocomotionType.OnlyFree) return;
            isStrafing = !isStrafing;
        }

        public virtual void Jump()
        {
            // conditions to do this action
            bool jumpConditions = isGrounded && !isJumping;
            // return if jumpCondigions is false
            if (!jumpConditions) return;
            // trigger jump behaviour
            jumpCounter = jumpTimer;            
            isJumping = true;
            //sound
            if (JumpSound != null)
            {
                AudioSource.PlayClipAtPoint(JumpSound, this.transform.position);
            }
            // trigger jump animations            
            if (_rigidbody.velocity.magnitude < 1)
                animator.CrossFadeInFixedTime("Jump", 0.1f);
            else
                animator.CrossFadeInFixedTime("JumpMove", 0.2f);
        }

        public virtual void RotateWithAnotherTransform(Transform referenceTransform)
        {
            var newRotation = new Vector3(transform.eulerAngles.x, referenceTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), strafeRotationSpeed * Time.fixedDeltaTime);
            targetRotation = transform.rotation;
        }
        void OnCollisionExit(Collision coll)
        {
            if (coll.gameObject.tag.Equals("Floor"))
            {
                //mFloorTouched = false;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Coin"))
            {
                if (CoinSound != null)
                {
                    //mAudioSource.PlayOneShot(CoinSound);
                    AudioSource.PlayClipAtPoint(CoinSound, this.transform.position);
                }
                Destroy(other.gameObject);
            }
        }
    }
}