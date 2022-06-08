using System.Collections.Generic;

namespace W08_Prepare_phone
{
    public class Director
    {
        public List<string> textMessages = new List<string>();

        public void RunIt()
        {
            Phone phone = new Phone(1111);
            CameraPhone cameraPhone = new CameraPhone(phone.phoneNumber);

            Console.WriteLine("Phone");
            Console.WriteLine(phone.GetNumber());
            phone.PlaceCall(3333);
            phone.PlaceText(4444, "Works once");
            phone.SaveText("Works 1");
            phone.SaveText("Works 2");
            phone.SaveText("Works 3");
            textMessages = phone.GetTexts();
            foreach (string textMessage in textMessages)
            {
                Console.WriteLine(textMessage);
            }
            
            Console.WriteLine("\nCamera Phone");
            Console.WriteLine(cameraPhone.GetNumber());
            cameraPhone.PlaceCall(5555);
            cameraPhone.PlaceText(6666, "Works again");
            cameraPhone.SaveText("Works 4");
            cameraPhone.SaveText("Works 5");
            cameraPhone.SaveText("Works 6");
            textMessages = cameraPhone.GetTexts();
            foreach (string textMessage in textMessages)
            {
                Console.WriteLine(textMessage);
            }

            cameraPhone.TakePicture("Cat_pic");
            cameraPhone.TakePicture("Dog_pic");
            cameraPhone.TakePicture("Fish_pic");
            foreach (string picture in cameraPhone.pictures)
            {
                Console.WriteLine(picture);
            }
        }
    }
}