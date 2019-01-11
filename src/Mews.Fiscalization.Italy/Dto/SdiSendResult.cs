using FuncSharp;

namespace Mews.Fiscalization.Italy.Dto
{
    public class SdiResponse : Coproduct2<SdiFileInfo, SdiError>
    {
        public SdiResponse(SdiFileInfo sdiFileInfo)
            : base(sdiFileInfo)
        {
        }

        public SdiResponse(SdiError sdiError)
            : base(sdiError)
        {
        }
    }
}