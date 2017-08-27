using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotDemoCanal.Model
{
    public abstract class BaseModel
    {
        public string Nombre { get; set; }
        public string Foto { get; set; }

        public IMessageActivity ToMessage(IDialogContext context)
        {
            var reply = context.MakeMessage();
            reply.Attachments = new List<Attachment>
    {
            ToAttachment(context)
    };

            return reply;
        }

        public static IMessageActivity ToMessage(IEnumerable<BaseModel> model, IDialogContext context)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = "carousel";
            reply.Attachments = model.Select(c => c.ToAttachment(context)).ToList();
            return reply;
        }

        public abstract Attachment ToAttachment(IDialogContext context);
    }
}