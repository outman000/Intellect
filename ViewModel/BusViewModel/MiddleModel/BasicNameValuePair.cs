using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class BasicNameValuePair
    {
        private static  long serialVersionUID = -6437800749411518984L;
        private readonly string   name;
        private readonly string   value;

    public BasicNameValuePair(string name, string value)
        {
            if (name == null)
                name = "Name";

            this.name = name;
            this.value = value;
        }

        public string getName()
        {
            return this.name;
        }

        public string getValue()
        {
            return this.value;
        }

        public string toString()
        {
            if (this.value == null)
            {
                return this.name;
            }
            else
            {
                int len = this.name.Length + 1 + this.value.Length;
                StringBuilder buffer = new StringBuilder(len);
                buffer.Append(this.name);
                buffer.Append("=");
                buffer.Append(this.value);
                return buffer.ToString();
            }
        }

       
  
    }
}
