<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\RendezVous;

class RendezVousController extends Controller
{
    public function index()
    {
        return response()->json(RendezVous::with(['soin', 'patient', 'medecin', 'moyenPaiement'])->get());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'heure_debut' => 'required|string',
            'heure_fin' => 'required|string',
            'statut' => 'required|string',
            'date_demande' => 'required|date',
            'id_soin' => 'required|exists:soins,id',
            'id_patient' => 'required|exists:patients,id',
            'id_medecin' => 'required|exists:medecins,id',
            'id_moyen_paiement' => 'required|exists:moyen_paiements,id',
        ]);
        $rdv = RendezVous::create($validated);
        return response()->json($rdv, 201);
    }

    public function show($id)
    {
        $rdv = RendezVous::with(['soin', 'patient', 'medecin', 'moyenPaiement'])->findOrFail($id);
        return response()->json($rdv);
    }

    public function update(Request $request, $id)
    {
        $rdv = RendezVous::findOrFail($id);
        $validated = $request->validate([
            'heure_debut' => 'string',
            'heure_fin' => 'string',
            'statut' => 'string',
            'date_demande' => 'date',
            'id_soin' => 'exists:soins,id',
            'id_patient' => 'exists:patients,id',
            'id_medecin' => 'exists:medecins,id',
            'id_moyen_paiement' => 'exists:moyen_paiements,id',
        ]);
        $rdv->update($validated);
        return response()->json($rdv);
    }

    public function destroy($id)
    {
        RendezVous::findOrFail($id)->delete();
        return response()->json(['message' => 'Rendez-vous supprimé']);
    }
}
