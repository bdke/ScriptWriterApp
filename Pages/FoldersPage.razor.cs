using Microsoft.AspNetCore.Components.Web;
using ScriptWriterApp.Data;

namespace ScriptWriterApp.Pages
{
    public partial class FoldersPage
    {
        //create
        private string? InputName;

        private void GetInputName(string value)
        {
            InputName = value;
        }

        private async Task CreateNewFolder()
        {
            if (foldersData != null)
            {
                foldersData.Add(new FoldersData() { FolderName = InputName, FoldersDataID = FolderID });
                foreach (FoldersData data in foldersData)
                {
                    var result = await foldersAccessService.UpdateValueAsync(data);
                    if (!result)
                    {
                        await foldersAccessService.AddValueAsync(data);
                    }
                }
            }
            else
            {
                foldersData = new List<FoldersData> { new FoldersData() { FolderName = InputName, FoldersDataID = FolderID } };
            }

            DialogService.Close();
            StateHasChanged();
        }

        private async Task CreateNewFile()
        {
            if (currentFolderPages != null)
            {
                currentFolderPages.Add(new PagesData() { FoldersDataID = FolderID, Title = (InputName != null) ? InputName : "Untitled", Texts = "Hello World!\n\n", pTexts = "Hello World!\n\n" });
                foreach (PagesData pagesData in currentFolderPages)
                {
                    bool result = await pagesDataAccess.UpdateValueAsync(pagesData);
                    if (!result)
                    {
                        await pagesDataAccess.AddValueAsync(pagesData);
                    }
                }
            }
            else
            {
                await pagesDataAccess.AddValueAsync(new PagesData() { FoldersDataID = FolderID, Title = (InputName != null) ? InputName : "Untitled", Texts = "Hello World!\n\n", pTexts = "Hello World!\n\n" });
            }
            DialogService.Close();
            StateHasChanged();
        }

        private async Task RemoveFolder(MouseEventArgs args, FoldersData folder)
        {
            await foldersAccessService.DeleteValueAsync(folder);
            Nav.NavigateTo($"/writer/folder/{FolderID}", true);
            StateHasChanged();
        }

        private async Task RemoveFile(MouseEventArgs args, PagesData page)
        {
            await pagesDataAccess.DeleteValueAsync(page);
            Nav.NavigateTo($"/writer/folder/{FolderID}", true);
            StateHasChanged();
        }

        private async Task RenameFolder(MouseEventArgs args, FoldersData folder)
        {
            folder.FolderName = InputName;
            await foldersAccessService.UpdateValueAsync(folder);
            StateHasChanged();
            DialogService.Close();
        }

        private async Task RenameFile(PagesData page)
        {
            StateHasChanged();
        }
    }
}
