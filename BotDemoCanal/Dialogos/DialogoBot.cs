using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BotDemoCanal.Model;
using Microsoft.Bot.Builder.Dialogs;

namespace BotDemoCanal.Dialogos
{
    [Serializable]
    public class DialogoBot:IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hola bienvenido al PulpBot, que quieres saber?");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            ShowOptions(context);
        }

        private void ShowOptions(IDialogContext context)
        {
            var opciones = new[] { "Personajes", "Lugares" };
            PromptDialog.Choice(context, OpcionSelectedAsync, opciones, "Que quieres saber?", "Elige una opcion correcta");
        }

        private async Task OpcionSelectedAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var opcion = await argument;
            switch (opcion)
            {
                case "Personajes":
                    var choices = FakeData.Personajes.Keys.ToArray();
                    PromptDialog.Choice(context, PersonajeSelectedAsync, choices, "Elige un personaje", "Elige una opcion correcta");
                    break;
                case "Lugares":
                    var opcionesValidas = string.Join(",", FakeData.Ubicaciones.Keys.ToArray());
                    PromptDialog.Text(context, UbicacionSelectedAsync, $"Que lugar quieres ver [{opcionesValidas}]", "Elige una opcion correcta", 3);
                    break;

                default:
                    ShowOptions(context);
                    break;
            }
        }

        private async Task PersonajeSelectedAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var opcion = await argument;
            var personaje = FakeData.Personajes.ContainsKey(opcion) ? FakeData.Personajes[opcion] : null;
            if (personaje != null)
            {
                await context.PostAsync(personaje.ToMessage(context));
            }
            else
            {
                await context.PostAsync($"La opcion, {opcion} no es correcta");
            }

            ShowOptions(context);
        }

        private async Task UbicacionSelectedAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var opcion = await argument;
            var ubicacion = FakeData.Ubicaciones.ContainsKey(opcion) ? FakeData.Ubicaciones[opcion] : null;
            if (ubicacion != null)
            {
                await context.PostAsync(ubicacion.ToMessage(context));
            }
            else
            {
                await context.PostAsync($"La opcion, {opcion} no es correcta");
            }

            ShowOptions(context);
        }

    }
}