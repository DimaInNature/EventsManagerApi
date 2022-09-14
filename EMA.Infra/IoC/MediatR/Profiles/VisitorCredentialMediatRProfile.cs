namespace EMA.Infra.IoC.MediatR.Profiles;

public static class VisitorCredentialMediatRProfile
{
    public static void AddVisitorCredentialMediatRProfile(
       this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVisitorCredentialCommand>();
        services.AddScoped<IRequestHandler<CreateVisitorCredentialCommand, bool>, CreateVisitorCredentialCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVisitorCredentialCommand>();
        services.AddScoped<IRequestHandler<UpdateVisitorCredentialCommand, bool>, UpdateVisitorCredentialCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVisitorCredentialCommand>();
        services.AddScoped<IRequestHandler<DeleteVisitorCredentialCommand, bool>, DeleteVisitorCredentialCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<VisitorCredentialEntity?>, GetVisitorCredentialQuery>();
        services.AddScoped<IRequestHandler<GetVisitorCredentialQuery, VisitorCredentialEntity?>, GetVisitorCredentialQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VisitorCredentialEntity>>, GetVisitorCredentialsListQuery>();
        services.AddScoped<IRequestHandler<GetVisitorCredentialsListQuery, IEnumerable<VisitorCredentialEntity>>, GetVisitorCredentialsListQueryHandler>();

        #endregion
    }
}