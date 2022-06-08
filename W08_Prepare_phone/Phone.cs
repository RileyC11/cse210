using System.Collections.Generic;

namespace W08_Prepare_phone
{
    public class Phone
    {
        public long phoneNumber;
        public List<string> textMessages = new List<string>();
        
        public Phone(long phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void PlaceCall(long numberToCall)
        {
            Console.WriteLine($"You are calling {numberToCall}...");
        }

        public void PlaceText(long numberToText, string messageToText)
        {
            Console.WriteLine($"You sent '{messageToText}' to {numberToText}.");
        }

        public void SaveText(string messageToSave)
        {
            textMessages.Add(messageToSave);
        }

        public List<string> GetTexts()
        {
            return textMessages;
        }

        public long GetNumber()
        {
            return phoneNumber;
        }
    }
}