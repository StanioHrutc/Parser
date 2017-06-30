using AngleSharp.Dom.Html;


namespace Purser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
