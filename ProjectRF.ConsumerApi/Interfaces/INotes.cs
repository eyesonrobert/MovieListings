using ProjectRF.ConsumerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRF.ConsumerApi.Interfaces
{
    public interface INotes
    {
        List<NotesDomain> SelectAll();
        NotesDomain SelectById(int id);
        void Update(NotesUpdateRequest model);
        void Delete(int id);
        int Insert(NotesAddRequest model);

    }
}
