// <copyright file="CustomerRegistrationModel.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Inputs;

/// <summary>
/// The GraphQL input model for customer registration.
/// </summary>
/// <param name="FirstName">First name of the registering customer.</param>
/// <param name="LastName">Last name of the registering customer.</param>
/// <param name="EmailAddress">E-mail address of the registering customer.</param>
/// <param name="Password">The password of the registering customer.</param>
public record CustomerRegistrationModel(string FirstName, string LastName, string EmailAddress, string Password);