﻿namespace Product.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
            //app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(enpoints =>
            {
                enpoints.MapDefaultControllerRoute();
            });
        }
    }
}
