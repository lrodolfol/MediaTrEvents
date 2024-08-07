namespace MediaTr.Manager.Configurations;

public static class APIDoc
{
    public static void AddAPIDoc(this WebApplication web)
    {
        if (web.Environment.IsDevelopment())
        {
            web.UseSwagger();
            web.UseSwaggerUI();
        }
    }
}
