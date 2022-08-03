using CustomerCarePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CustomerCarePortal.Pages.Workflows
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
    public class DetailsModel : PageModel
    {
        private readonly CustomerCarePortal.Data.ApplicationDbContext _context;

        public DetailsModel(CustomerCarePortal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Workflow Workflow { get; set; } = default!; 
      public List<Transition> Transitions { get; set; } = default!; 
      public IList<State> States { get; set; } = default!; 
      public State InitialState { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workflows == null)
            {
                return NotFound();
            }

            var workflow = await _context.Workflows
                .Include(w=>w.States)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workflow == null)
            {
                return NotFound();
            }
            else
            {
                Workflow = workflow;
                if (Workflow.States is not null)
                {
                    States = Workflow.States;
                    Transitions = new List<Transition>();
                    IList<Transition> transitions = await _context.Transitions.ToListAsync();
                    foreach (State state in Workflow.States)
                    {
                        if(state.Id == workflow.IntialStateId) {
                            InitialState = state;
                        }
                        foreach (Transition transition in transitions)
                        {
                            if (transition.SourceStateId == state.Id)
                            {
                                Transitions.Add(transition);
                            }
                        }
                    }
                }
            }
            return Page();
        }
    }
}
