using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSetings parserSettings;


        HtmlLoader loader;

        bool isActive;

        #region Properties

        public event Action<object, T> OnNewData;

        public event Action<object> OnCompleted;

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        } 

        public IParserSetings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;

                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
#endregion

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSetings parserSettings) : this(parser)
        {
            this.parser = parser;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i);

                var domParser = new HtmlParser();

                var documentik = await domParser.ParseAsync(source);

                var result = parser.Parse(documentik);

                OnNewData?.Invoke(this, result);
            }

            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
