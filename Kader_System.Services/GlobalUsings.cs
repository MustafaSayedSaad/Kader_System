﻿global using Kader_System.Domain.Dtos.Request.Auth;
global using Kader_System.Domain.Dtos.Response;
global using Kader_System.Domain.Dtos.Response.Auth;
global using AutoMapper;
global using Kader_System.Domain.Interfaces;
global using Kader_System.Domain.Options;
global using Kader_System.Services.IServices.Auth;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Microsoft.Extensions.Localization;
global using static Kader_System.Domain.Constants.SD;
global using Microsoft.Extensions.Logging;
global using Kader_System.Domain.Models.Auth;
global using Kader_System.Domain;
global using Microsoft.AspNetCore.Http;
global using Kader_System.Domain.Extensions;
global using System.Linq.Expressions;
global using Microsoft.AspNetCore.SignalR;
global using Kader_System.Domain.Dtos.Response.Perm;
global using Kader_System.Domain.Constants;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.Extensions.Options;
global using Kader_System.Domain.Dtos.Request.Perm;
global using Kader_System.Domain.Constants.Enums;
global using Kader_System.Domain.DTOs.Response.Setting;
global using Kader_System.Domain.Dtos.Request.Setting;
global using Kader_System.Services.IServices.Setting;
global using Kader_System.Domain.Models.Setting;
global using Kader_System.Domain.Interfaces.Logging;
global using Newtonsoft.Json;