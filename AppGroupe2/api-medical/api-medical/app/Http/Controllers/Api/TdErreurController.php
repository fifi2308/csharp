<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Td_Erreur;

class TdErreurController extends Controller
{
    public function index()
    {
        return response()->json(Td_Erreur::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'data_erreur' => 'required|date',
            'titre_erreur' => 'required|string|max:200',
            'description_erreur' => 'required|string|max:2000',
        ]);
        $erreur = Td_Erreur::create($validated);
        return response()->json($erreur, 201);
    }

    public function show($id)
    {
        $erreur = Td_Erreur::findOrFail($id);
        return response()->json($erreur);
    }

    public function update(Request $request, $id)
    {
        $erreur = Td_Erreur::findOrFail($id);
        $validated = $request->validate([
            'data_erreur' => 'date',
            'titre_erreur' => 'string|max:200',
            'description_erreur' => 'string|max:2000',
        ]);
        $erreur->update($validated);
        return response()->json($erreur);
    }

    public function destroy($id)
    {
        Td_Erreur::findOrFail($id)->delete();
        return response()->json(['message' => 'Erreur supprimée']);
    }
}
