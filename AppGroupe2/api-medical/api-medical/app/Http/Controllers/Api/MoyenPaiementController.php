<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\MoyenPaiement;

class MoyenPaiementController extends Controller
{
    public function index()
    {
        return response()->json(MoyenPaiement::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'nom_mp' => 'required|string',
            'libelle' => 'nullable|string',
        ]);
        $mp = MoyenPaiement::create($validated);
        return response()->json($mp, 201);
    }

    public function show($id)
    {
        $mp = MoyenPaiement::findOrFail($id);
        return response()->json($mp);
    }

    public function update(Request $request, $id)
    {
        $mp = MoyenPaiement::findOrFail($id);
        $validated = $request->validate([
            'nom_mp' => 'string',
            'libelle' => 'string',
        ]);
        $mp->update($validated);
        return response()->json($mp);
    }

    public function destroy($id)
    {
        MoyenPaiement::findOrFail($id)->delete();
        return response()->json(['message' => 'Moyen de paiement supprimé']);
    }
}
