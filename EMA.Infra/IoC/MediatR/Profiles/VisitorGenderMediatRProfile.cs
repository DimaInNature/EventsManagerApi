namespace EMA.Infra.IoC.MediatR.Profiles;

public static class VisitorGenderMediatRProfile
{
    public static void AddVisitorGenderMediatRProfile(
       this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVisitorGenderCommand>();
        services.AddScoped<IRequestHandler<CreateVisitorGenderCommand, bool>, CreateVisitorGenderCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVisitorGenderCommand>();
        services.AddScoped<IRequestHandler<UpdateVisitorGenderCommand, bool>, UpdateVisitorGenderCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVisitorGenderCommand>();
        services.AddScoped<IRequestHandler<DeleteVisitorGenderCommand, bool>, DeleteVisitorGenderCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<VisitorGenderEntity?>, GetVisitorGenderQuery>();
        services.AddScoped<IRequestHandler<GetVisitorGenderQuery, VisitorGenderEntity?>, GetVisitorGenderQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VisitorGenderEntity>>, GetVisitorGendersListQuery>();
        services.AddScoped<IRequestHandler<GetVisitorGendersListQuery, IEnumerable<VisitorGenderEntity>>, GetVisitorGendersListQueryHandler>();

        #endregion
    }
}