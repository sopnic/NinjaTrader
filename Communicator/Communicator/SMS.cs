﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Communicator
{
	public class SMS
	{
		public void sendSMS(string CellNumber, string SMSMessage)
		{

			WebClient client = new WebClient();
			// Add a user agent header in case the requested URI contains a query.

			client.QueryString.Add("user", "pieterf33@gmail.com");
			client.QueryString.Add("password", "1rachelle");
			client.QueryString.Add("api_id", "3388841");
			client.QueryString.Add("to", CellNumber);
			client.QueryString.Add("text", SMSMessage);
			string baseurl = "http://api.clickatell.com/http/sendmsg";
			Stream data = client.OpenRead(baseurl);
			StreamReader reader = new StreamReader(data);
			string s = reader.ReadToEnd();
			data.Close();
			reader.Close();
			Debug.WriteLine(s);



		}



		public int GetSmsBalance()
		{
			try
			{


				WebClient client = new WebClient();


				string URL = "http://api.clickatell.com/http/getbalance?api_id=3388841&user=pieterf33@gmail.com&password=1rachelle";

				string balance = client.DownloadString(URL);
				string Balance = balance.Remove(0, 7).Trim();

				int bal = Convert.ToInt16(double.Parse(Balance));

				return bal;
			}
			catch { return 0; }

		}

	}
}
