using ScriptWriterApp.Data;

namespace ScriptWriterApp.Pages
{
    public partial class WritePage
    {
        #region ChangeHistoryType
        private async Task ChangeHistoryM(int i, string[] tmpValue)
        {
            await changeHistoryAccess.AddValueAsync(new ChangeHistory()
            {
                DateTime = DateTime.Now,
                FilePath = @$"/writer/pages/{PageID}",
                LineNum = i + 1,
                Origin = pTextValue[i],
                Modified = tmpValue[i],
                Status = 'M'
            }
            );
            log.Debug("Change History M");
        }

        private async Task ChangeHistoryMD(int i)
        {
            if (pTextValue[i].Replace("\n", "") == "") { return; }

            await changeHistoryAccess.AddValueAsync(new ChangeHistory()
            {
                DateTime = DateTime.Now,
                FilePath = @$"/writer/pages/{PageID}",
                LineNum = i + 1,
                Origin = pTextValue[i],
                Modified = "",
                Status = 'Q'
            }
            );
            log.Debug("Change History MD");
        }

        private async Task ChangeHistoryMA(int i, string[] tmpValue)
        {
            if (tmpValue[i].Replace("\n", "") == "") { return; }

            await changeHistoryAccess.AddValueAsync(new ChangeHistory()
            {
                DateTime = DateTime.Now,
                FilePath = @$"/writer/pages/{PageID}",
                LineNum = i + 1,
                Origin = "",
                Modified = tmpValue[i],
                Status = 'C'
            }
            );
            log.Debug("Change History MA");
        }
        #endregion
        private async Task TextUpdate(string value, bool clear = false)
        {
            if (clear)
            {
                pTextValue = new string[] { };
                currentPageData.pTexts = "";
                currentPageData.Texts = _myText;
                await pagesDataAccess.UpdateValueAsync(currentPageData);
            }
            else
            {
                pTextValue = value.Split("\n\n");
                currentPageData.pTexts = string.Join("\n\n", pTextValue);
                currentPageData.Texts = _myText;
                await pagesDataAccess.UpdateValueAsync(currentPageData);
            }
        }

        private async Task DetectNewLine(string value, bool manual = false)
        {
            try
            {
                if (value.Last() == '\n' && value[value.Length - 2] != '\n' && value != "" || manual)
                {
                    string[] tmpValue = value.Split("\n\n");
                    _myText += "\n";
                    if (pTextValue.Length > tmpValue.Length)
                    {
                        for (int i = 0; i < pTextValue.Length; i++)
                        {
                            try
                            {
                                if (pTextValue[i].Replace("\n", "") != tmpValue[i].Replace("\n", "") && pTextValue[i].Replace("\n", "") != "")
                                {
                                    await ChangeHistoryM(i, tmpValue);
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                await ChangeHistoryMD(i);
                            }
                        }
                        await TextUpdate(value);
                    }
                    else if (pTextValue.Length < tmpValue.Length)
                    {
                        for (int i = 0; i < tmpValue.Length; i++)
                        {
                            try
                            {
                                if (pTextValue[i].Replace("\n", "") != tmpValue[i].Replace("\n", "") && pTextValue[i].Replace("\n", "") != "")
                                {
                                    await ChangeHistoryM(i, tmpValue);
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                await ChangeHistoryMA(i, tmpValue);
                            }
                        }
                        await TextUpdate(value);
                    }
                    else if (pTextValue.Length == tmpValue.Length)
                    {
                        for (int i = 0; i < tmpValue.Length; i++)
                        {
                            if (pTextValue[i].Replace("\n", "") != tmpValue[i].Replace("\n", "") && pTextValue[i].Replace("\n", "") != "")
                            {
                                await ChangeHistoryM(i, tmpValue);
                            }
                        }
                        await TextUpdate(value);
                    }
                }
                else if (value == "")
                {
                    for (int i = 0; i < pTextValue.Length; i++)
                    {
                        await ChangeHistoryMD(i);
                    }
                    await TextUpdate(value, true);
                }


            }
            catch (IndexOutOfRangeException)
            {
                for (int i = 0; i < pTextValue.Length; i++)
                {
                    await ChangeHistoryMD(i);
                }
                await TextUpdate(value, true);
            }
            catch (InvalidOperationException)
            {
                for (int i = 0; i < pTextValue.Length; i++)
                {
                    await ChangeHistoryMD(i);
                }
                await TextUpdate(value, true);
            }
            catch (Exception e)
            {
                log.Critical(e.Message);
                log.Critical(e.StackTrace);
            }
        }
    }
}
