// <copyright file="LoginWithPassword.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Inputs;

/// <summary>
/// The GraphQL input model for log in with simply password.
/// </summary>
/// <param name="UserName">User's identifier (e-mail).</param>
/// <param name="Password">Password used to log in.</param>
/// <param name="RememberMe">The remember-me Checkbox value.</param>
public record LoginWithPassword(string UserName, string Password, bool RememberMe);