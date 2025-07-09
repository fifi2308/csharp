<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Secretaire;

class SecretaireController extends Controller
{
    public function index()
    {
        return response()->json(Secretaire::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'telephone_fixe' => 'nullable|string|max:15',
            'id_personne' => 'required|exists:personnes,id',
        ]);
        $secretaire = Secretaire::create($validated);
        return response()->json($secretaire, 201);
    }

    public function show($id)
    {
        $secretaire = Secretaire::findOrFail($id);
        return response()->json($secretaire);
    }

    public function update(Request $request, $id)
    {
        $secretaire = Secretaire::findOrFail($id);
        $validated = $request->validate([
            'telephone_fixe' => 'string|max:15',
            'id_personne' => 'exists:personnes,id',
        ]);
        $secretaire->update($validated);
        return response()->json($secretaire);
    }

    public function destroy($id)
    {
        Secretaire::findOrFail($id)->delete();
        return response()->json(['message' => 'Secrétaire supprimé']);
    }
}
