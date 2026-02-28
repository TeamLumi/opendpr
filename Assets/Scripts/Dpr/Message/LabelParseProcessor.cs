using Nintendo.MessageStudio.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dpr.Message
{
    public class LabelParseProcessor : TagProcessorBase
    {
        private List<LabelTagDataModel> tagDataModelList = new List<LabelTagDataModel>();
        private List<string> strList = new List<string>();
        private MessageTagAnalyzer tagAnalyzer = new MessageTagAnalyzer();
        private StringBuilder strBuilder = new StringBuilder(MessageDataConstants.TEXT_CAPACITY_SIZE);
        private char charSingleQuotation;
        private char charDoubleQuotation;
        private char charAfterSingleQuotation;
        private char charAfterDoubleQuotation;
        private bool isCallReset;

        public void Initialize()
        {
            charSingleQuotation = Convert.ToChar(MessageDataConstants.SINGLE_QUOTATION_CODE);
            charDoubleQuotation = Convert.ToChar(MessageDataConstants.DOUBLE_QUOTATION_CODE);
            charAfterSingleQuotation = Convert.ToChar(MessageDataConstants.AFTER_SINGLE_QUOTATION_CODE);
            charAfterDoubleQuotation = Convert.ToChar(MessageDataConstants.AFTER_DOUBLE_QUOTATION_CODE);

            tagDataModelList.Clear();
            strList.Clear();

            isCallReset = true;
        }

        // TODO
        public LabelParseDataModel CreateParseDataModel() { return null; }

        // TODO
        public void Reset() { }

        // TODO
        protected override void ProcessChar(char c) { }

        // TODO
        protected override void ProcessEnd() { }

        // TODO
        private bool IsExcludeChar(char c) { return false; }

        // TODO
        private bool IsNewLineChar(char c) { return false; }

        public bool IsReplaceCharacter(char c, out char afterChar)
        {
        	afterChar = c;
        	if (this.charSingleQuotation == c) {
        	  afterChar = this.charAfterSingleQuotation;
        	  return true;
        	}
        	if (this.charDoubleQuotation == c) {
        	  afterChar = this.charAfterDoubleQuotation;
        	  return true;
        	}
        	return false;
        }

        // TODO
        private void AddCurrentMessage() { }

        // TODO
        private void AddNewLineCharMark(char c) { }

        // TODO
        protected override void ProcessCustomTag(CustomTagInfo tagInfo) { }

        // TODO
        protected override void ProcessColorTag(ColorTagInfo colorTagInfo) { }

        // TODO
        protected override void ProcessFontTag(FontTagInfo fontTagInfo) { }

        // TODO
        protected override void ProcessPageBreakTag(PageBreakTagInfo pageBreakTagInfo) { }

        // TODO
        protected override void ProcessRubyTag(RubyTagInfo rubyTagInfo) { }

        // TODO
        protected override void ProcessSizeTag(SizeTagInfo sizeTagInfo) { }
    }
}
