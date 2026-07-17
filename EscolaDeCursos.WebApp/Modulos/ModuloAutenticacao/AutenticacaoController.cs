using EscolaDeCursos.Dominio.Modulos.ModuloInstituicao;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAutenticacao.Views;

[AllowAnonymous]
public class AutenticacaoController(
    UserManager<IdentityUser<Guid>> userManager,
    SignInManager<IdentityUser<Guid>> signInManager,
    EscolaDeCursosDbContext dbContext
) : Controller
{
    public ActionResult Registrar()
    {
        if (signInManager.IsSignedIn(User))
            return RedirectToAction("Index", "Home");

        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Registrar(RegistrarViewModel vm)
    {
        if (signInManager.IsSignedIn(User))
            return RedirectToAction("Index", "Home");

        if (!ModelState.IsValid)
            return View(vm);

        IdentityUser<Guid> user = new()
        {
            Id = Guid.CreateVersion7(),
            UserName = vm.Email,
            Email = vm.Email,
        };
        //cria o usuario e protege a senha
        IdentityResult resultado = await userManager.CreateAsync(user, vm.Senha);

        if (!resultado.Succeeded)
        {
            foreach (IdentityError erro in resultado.Errors)
                ModelState.AddModelError(string.Empty, erro.Description);

            return View(vm);
        }

        Instituicao i = new()
        {
            UserId = user.Id,
            Nome = vm.Nome
        };

        dbContext.Insituicoes.Add(i);
        await dbContext.SaveChangesAsync();

        await signInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction("Index", "Home");
    }

    public ActionResult Entrar(string? returnUrl = null)
    {
        if (signInManager.IsSignedIn(User))
            return RedirectToAction("Index", "Home");

        ViewBag.ReturnUrl = returnUrl;

        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Entrar(EntrarViewModel vm)
    {
        if (signInManager.IsSignedIn(User))
            return RedirectToAction("Index", "Home");

        if (!ModelState.IsValid)
            return View(vm);

        Microsoft.AspNetCore.Identity.SignInResult resultado = await signInManager.PasswordSignInAsync(
            vm.Email, vm.Senha, vm.LembrarMe, lockoutOnFailure: true
        );

        if (resultado.Succeeded)
        {
            if (Url.IsLocalUrl(vm.ReturnUrl))
                return Redirect(vm.ReturnUrl);

            return RedirectToAction("Index", "Home");
        }

        if (resultado.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "Conta bloqueada, tente novamanete mais tarde!");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Email ou senha inválidos!");
        }

        return View(vm);
    }

    [HttpPost]
    public async Task<ActionResult> Sair()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction(nameof(Entrar));
    }
}
