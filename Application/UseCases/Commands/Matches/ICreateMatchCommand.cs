﻿using Application.DTO.Matches;
using ProjectASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Matches
{
    public interface ICreateMatchCommand : ICommand<CreateMatchDTO>
    {
    }
}