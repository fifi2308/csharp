<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Agenda;

class AgendaController extends Controller
{
    public function index()
    {
        return response()->json(Agenda::with('medecin', 'rendezVous')->get());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'date_planifie' => 'nullable|date',
            'titre' => 'nullable|string',
            'heure_debut' => 'nullable|string',
            'heure_fin' => 'nullable|string',
            'creneau' => 'nullable|integer',
            'lieu' => 'nullable|string',
            'statut' => 'nullable|string',
            'id_medecin' => 'required|exists:medecins,id',
        ]);
        $agenda = Agenda::create($validated);
        return response()->json($agenda, 201);
    }

    public function show($id)
    {
        $agenda = Agenda::with('medecin', 'rendezVous')->findOrFail($id);
        return response()->json($agenda);
    }

    public function update(Request $request, $id)
    {
        $agenda = Agenda::findOrFail($id);
        $validated = $request->validate([
            'date_planifie' => 'date',
            'titre' => 'string',
            'heure_debut' => 'string',
            'heure_fin' => 'string',
            'creneau' => 'integer',
            'lieu' => 'string',
            'statut' => 'string',
            'id_medecin' => 'exists:medecins,id',
        ]);
        $agenda->update($validated);
        return response()->json($agenda);
    }

    public function destroy($id)
    {
        Agenda::findOrFail($id)->delete();
        return response()->json(['message' => 'Agenda supprimé']);
    }
}
