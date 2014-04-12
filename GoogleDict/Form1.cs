using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions; 

namespace GoogleDict
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text=="")
			{
				MessageBox.Show("请填写单词，不要为空！谢谢！","提示");
			} 
			else
			{
				richTextBox1.Clear();
				WebClient we = new WebClient();
				byte[] myDataBuffer;
				we.Headers.Add("user-agent","Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36");
				try
				{
					myDataBuffer = we.DownloadData("https://translate.google.com.hk/translate_a/t?client=t&sl=en&tl=zh-CN&hl=zh-CN&sc=2&ie=UTF-8&oe=UTF-8&prev=enter&ssel=0&tsel=0&q=" + textBox1.Text);
				}
				catch (WebException ex)
				{
					//MessageBox.Show("服务器异常，请检查网络！","Error");
					MessageBox.Show(ex.Message);
					throw;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					throw;
				}
				
				string download = Encoding.UTF8.GetString(myDataBuffer);
				richTextBox1.AppendText(download);
			}
		
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar==(char)Keys.Enter)
			{
				button1.PerformClick();
			}
		}
	}
}
