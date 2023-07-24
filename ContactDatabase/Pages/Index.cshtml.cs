using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;

namespace ContactDatabase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EdgeDBClient _edgeDbClient;
        public List<Contact> Contacts { get; set; }

        public IndexModel(EdgeDBClient edgeDbClient)
        {
            _edgeDbClient = edgeDbClient;
        }

        public async Task OnGetAsync()
        {
            Contacts = await GetContactsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var contact = new Contact
            {
                FirstName = Request.Form["FirstName"],
                LastName = Request.Form["LastName"],
                Email = Request.Form["Email"],
                Title = Request.Form["Title"],
                Description = Request.Form["Description"],
                DateOfBirth = DateTime.Parse(Request.Form["DateOfBirth"]),
                MarriageStatus = Request.Form.ContainsKey("MarriageStatus")
            };

            await _edgeDbClient.ExecuteAsync("INSERT Contact { first_name := <str>$firstName, last_name := <str>$lastName, email := <str>$email, title := <str>$title, description := <str>$description, date_of_birth := <datetime>$dateOfBirth, marriage_status := <bool>$marriageStatus }",
                new Dictionary<string, object>
                {
                    { "firstName", contact.FirstName },
                    { "lastName", contact.LastName },
                    { "email", contact.Email },
                    { "title", contact.Title },
                    { "description", contact.Description },
                    { "dateOfBirth", contact.DateOfBirth },
                    { "marriageStatus", contact.MarriageStatus }
                });

            return RedirectToPage();
        }

        private async Task<List<Contact>> GetContactsAsync()
        {
            var result = await _edgeDbClient.QueryAsync<Contact>("SELECT Contact {FirstName := .first_name, LastName := .last_name, Email := .email, Title := .title, Description := .description, DateOfBirth := .date_of_birth, MarriageStatus := .marriage_status }");
            return result.ToList();
        }

    }

    public class Contact
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public bool MarriageStatus { get; set; }
    }
}
