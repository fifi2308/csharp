<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Specialite;

class SpecialiteController extends Controller
{
    public function index()
    {
        return response()->json(Specialite::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'code_specialite' => 'required|string|max:10',
            'nom_specialite' => 'required|string|max:100',
        ]);
        $specialite = Specialite::create($validated);
        return response()->json($specialite, 201);
    }

    public function show($id)
    {
        $specialite = Specialite::findOrFail($id);
        return response()->json($specialite);
    }

    public function update(Request $request, $id)
    {
        $specialite = Specialite::findOrFail($id);
        $validated = $request->validate([
            'code_specialite' => 'string|max:10',
            'nom_specialite' => 'string|max:100',
        ]);
        $specialite->update($validated);
        return response()->json($specialite);
    }

    public function destroy($id)
    {
        Specialite::findOrFail($id)->delete();
        return response()->json(['message' => 'Spécialité supprimée']);
    }
}
