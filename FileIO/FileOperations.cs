using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FileIO
{
    class FileOperations
    {

        String filePath=null;

        public String readFile()
        {
            string data=null;            
            try
            {
                data = File.ReadAllText(filePath);
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return data;
        }

        public void writeFile(String data)
        {
            try
            {
                File.WriteAllText(filePath, data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        public string[] readFileBylines()
        {
            String[] data = null;
            try
            {               
                data = File.ReadAllLines(filePath);                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }

        public void writeFileBylines(String[] data)
        {
            try
            {
                File.WriteAllLines(filePath, data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setPath(String path)
        {
            filePath = path;
        }

        public bool checkFilePathExists()
        {
            if (filePath==null)
            {
                return false;
            }
            else if(filePath == ""){
                return false;
            }
            else
            {
                return true;
            }        

        }

        public String getFilePath()
        {
            return filePath;
        }
    }
}
