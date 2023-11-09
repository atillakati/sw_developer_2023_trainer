using System;
using Vererbung_HAT_EIN.VehicleTypes;

namespace Vererbung_HAT_EIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Radio radio = new Radio();

            radio.ShowState();
            radio.Play();

            radio.ChangePowerState(DevicePower.On);
            radio.Frequency = 102.0;

            radio.ShowState();
            radio.Play();

            var meinAuto = new Vehicle();

            meinAuto.SetEntertainmentPower(true);
            Console.WriteLine(meinAuto.VehicleRadio.Frequency);
        }
    }
}
