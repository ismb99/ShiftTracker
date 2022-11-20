using AutoMapper;
using ShiftTracker.API.Interfaces;
using ShiftTracker.API.Models;
using ShiftTracker.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.API.Services
{
    public class ShiftService 
    {

        public static Shift CalculateMinutesByHour(CreateShiftDTO createShiftDTO)
        {
            decimal duration = CalculateDurationInMinutes(createShiftDTO);

            //decimal payPerMinutes = (decimal)MinutePay.normal;
            decimal payPerMinutes = 2.5m;

            decimal result = duration * payPerMinutes;

            var shift = new Shift()
            {
                Location = createShiftDTO.Location,
                End = createShiftDTO.End,
                Start = createShiftDTO.Start,
                Minutes = duration,
                Pay = result
            };
            return shift;
        }

        public static decimal CalculateDurationInMinutes(CreateShiftDTO createShiftDTO)
        {
            double result = (createShiftDTO.End - createShiftDTO.Start).TotalMinutes;

            decimal resultAsDecimal = Convert.ToDecimal(result);

            return resultAsDecimal;
        }

    }
}
