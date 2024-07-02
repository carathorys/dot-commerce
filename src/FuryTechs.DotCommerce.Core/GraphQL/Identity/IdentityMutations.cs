// <copyright file="IdentityMutations.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

using FuryTechs.DotCommerce.Core.Database.Entities.Identity;

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity;

using Extensions;
using Inputs;
using Types;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Mutations around Identity (login, logout, basic registration).
/// These methods will extend the existing <see cref="AdminAPI.Mutations"/> class.
/// </summary>
/// <typeparam name="TKey">Primary key type on identity tables.</typeparam>
[ExtendObjectType("Mutations")]
public sealed class IdentityMutations<TKey>
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// A mutation for the users to Log in to the application.
    /// </summary>
    /// <param name="input">Input for logging in.</param>
    /// <param name="totp">(optional) Time based onetime password.</param>
    /// <param name="signInManager">Dependency: signInManager instance.</param>
    /// <returns>Result of the signIn: <see cref="SignInResult"/>.</returns>
    public async Task<ILoginResult> Login(
        LoginWithPassword input,
        string? totp,
        [Service] SignInManager<User<TKey>> signInManager)
    {
        var (username, password, rememberMe) = input;
        var result = await signInManager.PasswordSignInAsync(username, password, rememberMe, true);
        if (!result.Succeeded)
        {
            return result.ToFailedLoginResult();
        }

        return new CurrentUser<TKey>()
        {
            Identifier = username,
        };
    }

    /// <summary>
    /// Mutation method to log out logged in user.
    /// </summary>
    /// <param name="signInManager">Dependency: signInManager instance.</param>
    /// <param name="accessor">Dependency: HTTP Context Accessor instance.</param>
    /// <returns><value>true</value> after a successful logout, <value>false</value> otherwise.</returns>
    [Authorize]
    public async Task<bool> Logout([Service] SignInManager<User<TKey>> signInManager, [Service] IHttpContextAccessor
        accessor)
    {
        if (accessor.HttpContext?.User == null || !signInManager.IsSignedIn(accessor.HttpContext.User))
        {
            return false;
        }

        await signInManager.SignOutAsync();
        return true;
    }

    /// <summary>
    /// Create a new customer registration via this mutation.
    /// </summary>
    /// <param name="input">
    /// Registration input model.
    /// </param>
    /// <param name="userManager">
    /// Dependency: <see cref="UserManager{TUser}" /> instance.
    /// </param>
    /// <returns>
    /// Result of the registration.
    /// </returns>
    public async Task<IdentityResult> RegisterIdentityAccount(
        CustomerRegistrationModel input,
        [Service] UserManager<User<TKey>> userManager)
    {
        return await userManager.CreateAsync(
            new User<TKey>()
            {
                Email = input.EmailAddress,
                UserName = input.EmailAddress,
                EmailConfirmed = true,
                TwoFactorEnabled = true,
            },
            input.Password);
    }
}