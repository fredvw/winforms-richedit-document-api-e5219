﻿using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Drawing;

namespace RichEditAPISample.CodeExamples
{
    public static class FormattingActions
    {
        static void FormatText(Document document)
        {
            #region #FormatText
            document.BeginUpdate();
            document.AppendText("Normal\nFormatted\nNormal");
            document.EndUpdate();
            // The target range is the second paragraph 
            DocumentRange range = document.Paragraphs[1].Range;

            // Create and customize an object  
            // that sets character formatting for the selected range
            CharacterProperties cp = document.BeginUpdateCharacters(range);
            cp.FontName = "Comic Sans MS";
            cp.FontSize = 18;
            cp.ForeColor = Color.Blue;
            cp.BackColor = Color.Snow;
            cp.Underline = UnderlineType.DoubleWave;
            cp.UnderlineColor = Color.Red;

            // Finalize modifications  
            // with this method call 
            document.EndUpdateCharacters(cp);
            #endregion #FormatText
        }

        static void ResetCharacterFormatting(Document document)
        {
            #region #ResetCharacterFormatting
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            // Set font size and font name of the characters in the first paragraph to default. 
            // Other character properties remain intact.
            DocumentRange range = document.Paragraphs[0].Range;
            CharacterProperties cp = document.BeginUpdateCharacters(range);
            cp.Reset(CharacterPropertiesMask.FontSize | CharacterPropertiesMask.FontName);
            document.EndUpdateCharacters(cp);
            #endregion #ResetCharacterFormatting
        }
        
        static void FormatParagraph(Document document)
        {
            #region #FormatParagraph
            document.BeginUpdate();
            document.AppendText("Modified Paragraph\nNormal\nNormal");
            document.EndUpdate();

            //The target range is the first paragraph
            DocumentPosition pos = document.Range.Start;
            DocumentRange range = document.CreateRange(pos, 0);

            // Create and customize an object  
            // that sets character formatting for the selected range
            ParagraphProperties pp = document.BeginUpdateParagraphs(range);
            // Center paragraph
            pp.Alignment = ParagraphAlignment.Center;
            // Set triple spacing
            pp.LineSpacingType = ParagraphLineSpacing.Multiple;
            pp.LineSpacingMultiplier = 3;
            // Set left indent at 0.5".
            // Default unit is 1/300 of an inch (a document unit).
            pp.LeftIndent = DevExpress.Office.Utils.Units.InchesToDocumentsF(0.5f);
            // Set tab stop at 1.5"
            TabInfoCollection tbiColl = pp.BeginUpdateTabs(true);
            TabInfo tbi = new DevExpress.XtraRichEdit.API.Native.TabInfo();
            tbi.Alignment = TabAlignmentType.Center;
            tbi.Position = DevExpress.Office.Utils.Units.InchesToDocumentsF(1.5f);
            tbiColl.Add(tbi);
            pp.EndUpdateTabs(tbiColl);

            //Finalize modifications
            // with this method call
            document.EndUpdateParagraphs(pp);
            #endregion #FormatParagraph
        }

        static void ResetParagraphFormatting(Document document)
        {
            #region #ResetParagraphFormatting
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            // Set alignment and indentation of the first line in the first paragraph to default. 
            // Other paragraph properties remain intact.
            DocumentRange range = document.Paragraphs[0].Range;
            ParagraphProperties cp = document.BeginUpdateParagraphs(range);
            cp.Reset(ParagraphPropertiesMask.Alignment | ParagraphPropertiesMask.FirstLineIndent);
            document.EndUpdateParagraphs(cp);
            #endregion #ResetParagraphFormatting
        }
    }
}
