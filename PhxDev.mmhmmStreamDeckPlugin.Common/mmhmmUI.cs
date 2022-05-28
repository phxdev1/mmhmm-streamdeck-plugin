using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using WindowsInput;
using System.Diagnostics;
using WindowsInput.Native;

namespace PhxDev.mmhmmStreamDeckPlugin.Common
{
    public class mmhmmUI
    {
        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint Msg);
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
        const int SW_RESTORE = 9;

        InputSimulator sim = new InputSimulator();
 
        //Process[] processes = Process.GetProcesses();
        public void NextSlide()
        {
            if (BringProcessToFront(GetMmhmmProcess())){
                sim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            }
        }

        public void PreviousSlide()
        {
            if (BringProcessToFront(GetMmhmmProcess()))
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.LEFT);
            }
        }

        public void ResetCamera()
        {
            if (BringProcessToFront(GetMmhmmProcess())){
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_R);
            }
        }

        public void ToggleCamera()
        {
            if (BringProcessToFront(GetMmhmmProcess()))
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.OEM_2);
            }
        }

        public void IncreasePresenterSize()
        {
            if (BringProcessToFront(GetMmhmmProcess())){
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.UP);
            }
        }

        public void DecreasePresenterSize()
        {
            if (BringProcessToFront(GetMmhmmProcess()))
            {
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.DOWN);
            }
            
        }

        public void ToggleAway()
        {

            if (BringProcessToFront(GetMmhmmProcess()))
            {
                sim.Keyboard.ModifiedKeyStroke(new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, VirtualKeyCode.VK_A);
            }
        }


        private bool BringProcessToFront(Process process)
        {
            if(process == null)
            {
                return false;
            }
            IntPtr handle = process.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
            return true;
        }

        private Process GetMmhmmProcess()
        {
            var processes = Process.GetProcessesByName("mmhmm");
            if(processes.Length == 0 || processes.Length > 1)
            {
                return null;
            }
            else
            {
                return processes[0];
            }
        }
    }
}
