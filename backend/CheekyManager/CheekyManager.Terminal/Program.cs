

using CheekyManager.Domain.Contexts;

var context = new CheekyManagerContext();

context.Database.EnsureCreated();
context.SaveChanges();
