using Kader_System.Domain.Constants.Enums;
using Kader_System.Domain.Models.Setting;

namespace Kader_System.DataAccess.Seeding;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        #region Users and their roles

        modelBuilder.Entity<ApplicationRole>()
            .HasData(
            new ApplicationRole()
            {
                Id = SuperAdmin.RoleId,
                Name = RolesEnums.Superadmin.ToString(),
                Title_name_en = SuperAdmin.RoleNameInAr,
                ConcurrencyStamp = "1",
                NormalizedName = "SUPERADMIN"
            });

        modelBuilder.Entity<ApplicationUser>()
            .HasData(
            new ApplicationUser()
            {
                Id = SuperAdmin.Id,
                UserName = "Mr_Mohammed",
                NormalizedUserName = "Mohammed",
                Email = "mohammed88@gmail.com",
                NormalizedEmail = "MOHAMMED88@GMAIL.COM",
                EmailConfirmed = true,
                IsActive = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, SuperAdmin.Password),
                VisiblePassword = SuperAdmin.Password
            }
            );

        modelBuilder.Entity<ApplicationUserRole>()
            .HasData(
           new ApplicationUserRole()
           {
               RoleId = SuperAdmin.RoleId,
               UserId = SuperAdmin.Id
           });

        #endregion

        modelBuilder.Entity<StAction>()
            .HasData(
           new StAction()
           {
               Id = 1,
               Name = "إظهار",
               NameInEnglish = ActionsEnums.View.ToString(),
           },
           new StAction()
           {
               Id = 2,
               Name = "اضافة",
               NameInEnglish = ActionsEnums.Add.ToString(),
           },
           new StAction()
           {
               Id = 3,
               Name = "تعديل",
               NameInEnglish = ActionsEnums.Edit.ToString(),
           },
           new StAction()
           {
               Id = 4,
               Name = "حذف",
               NameInEnglish = ActionsEnums.Delete.ToString(),
           },
           new StAction()
           {
               Id = 5,
               Name = "حذف نهائى",
               NameInEnglish = ActionsEnums.ForceDelete.ToString(),
           },
           new StAction()
           {
               Id = 6,
               Name = "طباعة",
               NameInEnglish = ActionsEnums.Ptint.ToString(),
           }
           );
    }

    public static void AddQueryFilterToAllEntitiesAssignableFrom<T>(this ModelBuilder modelBuilder,
     Expression<Func<T, bool>> expression)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(T).IsAssignableFrom(entityType.ClrType))
                continue;

            var parameterType = Expression.Parameter(entityType.ClrType);
            var expressionFilter = ReplacingExpressionVisitor.Replace(
                expression.Parameters.Single(), parameterType, expression.Body);

            var currentQueryFilter = entityType.GetQueryFilter();
            if (currentQueryFilter != null)
            {
                var currentExpressionFilter = ReplacingExpressionVisitor.Replace(
                    currentQueryFilter.Parameters.Single(), parameterType, currentQueryFilter.Body);
                expressionFilter = Expression.AndAlso(currentExpressionFilter, expressionFilter);
            }

            var lambdaExpression = Expression.Lambda(expressionFilter, parameterType);
            entityType.SetQueryFilter(lambdaExpression);
        }
    }
}
