﻿using System;

namespace Vererbung_HAT_EIN.VehicleTypes
{
    internal class Vehicle
    {
        private string _description;
        private ConsoleColor _color;
        private int _ps;
        private int _currentSpeed;
        private int _maxSpeed;

        private Radio _vehicleRadio;

        public Vehicle()
        {
            _description = "Family Car";
            _color = ConsoleColor.Blue;
            _ps = 140;
            _maxSpeed = 187;
            _currentSpeed = 0;
            _vehicleRadio = new Radio();
        }

        public Vehicle(string description, int maxSpeed, int ps, ConsoleColor color)
        {
            _description = description;
            _maxSpeed = maxSpeed;
            _ps = ps;
            _color = color;
            _currentSpeed = 0;
            _vehicleRadio = new Radio();
        }


        
        public int MaxSpeed
        {
            get { return _maxSpeed; }
        }

        public int CurrentSpeed
        {
            get { return _currentSpeed; }
        }

        public int Ps
        {
            get { return _ps; }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Description
        {
            get { return _description; }
        }


        public void SetEntertainmentPower(bool isOn)
        {
            if (isOn)
            {
                _vehicleRadio.ChangePowerState(DevicePower.On);
            }   
            else
            {
                _vehicleRadio.ChangePowerState(DevicePower.Off);
            }
        }

        public void MakeSound()
        {
            _vehicleRadio.Play();
        }

        public void SpeedUp(int delta)
        {
            if (_currentSpeed + delta < 0)
            {
                _currentSpeed = 0;
            }
            else if (_currentSpeed + delta > _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
            else
            {
                _currentSpeed += delta;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_description.ToUpper()} - {_ps} PS");
            Console.WriteLine($"Speed: {_currentSpeed} of max. {_maxSpeed} km/h");
            _vehicleRadio.ShowState();
        }
    }
}