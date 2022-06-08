using System.Collections.Generic;

namespace W08_Prepare_phone
{
    public class CameraPhone: Phone
    {
        public List<string> pictures = new List<string>();

        public CameraPhone(long phoneNumber) : base(phoneNumber)
        {

        }

        public void TakePicture(string pictureName)
        {
            pictures.Add(pictureName);
        }
    }
}