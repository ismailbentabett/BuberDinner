using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public record
AuthenticationResult
(
    User User,
    string Token

);