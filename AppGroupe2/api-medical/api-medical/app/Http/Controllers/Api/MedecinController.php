<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Medecin;

class MedecinController extends Controller
{
    public function index()
    {
        return response()->json(Medecin::with('specialite')->get());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'idspecialite' => 'nullable|exists:specialites,idspecialite',
            'numero_ordre' => 'nullable|string|max:10',
            'id_personne' => 'required|exists:personnes,id',
        ]);
        $medecin = Medecin::create($validated);
        return response()->json($medecin, 201);
    }

    public function show($id)
    {
        $medecin = Medecin::with('specialite')->findOrFail($id);
        return response()->json($medecin);
    }

    public function update(Request $request, $id)
    {
        $medecin = Medecin::findOrFail($id);
        $validated = $request->validate([
            'idspecialite' => 'exists:specialites,idspecialite',
            'numero_ordre' => 'string|max:10',
            'id_personne' => 'exists:personnes,id',
        ]);
        $medecin->update($validated);
        return response()->json($medecin);
    }

    public function destroy($id)
    {
        Medecin::findOrFail($id)->delete();
        return response()->json(['message' => 'Médecin supprimé']);
    }
}
