<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Utilisateur;

class UtilisateurController extends Controller
{
    public function index()
    {
        return response()->json(Utilisateur::with('role')->get());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'identifiant' => 'required|unique:utilisateurs,identifiant',
            'motdepasse' => 'required|min:6',
            'status' => 'boolean',
            'id_role' => 'required|exists:roles,id',
            'id_personne' => 'required|exists:personnes,id',
        ]);
        $validated['motdepasse'] = bcrypt($validated['motdepasse']);
        $utilisateur = Utilisateur::create($validated);
        return response()->json($utilisateur, 201);
    }

    public function show($id)
    {
        $utilisateur = Utilisateur::with('role')->findOrFail($id);
        return response()->json($utilisateur);
    }

    public function update(Request $request, $id)
    {
        $utilisateur = Utilisateur::findOrFail($id);
        $validated = $request->validate([
            'identifiant' => 'unique:utilisateurs,identifiant,' . $id,
            'motdepasse' => 'nullable|min:6',
            'status' => 'boolean',
            'id_role' => 'exists:roles,id',
            'id_personne' => 'exists:personnes,id',
        ]);
        if (isset($validated['motdepasse'])) {
            $validated['motdepasse'] = bcrypt($validated['motdepasse']);
        } else {
            unset($validated['motdepasse']);
        }
        $utilisateur->update($validated);
        return response()->json($utilisateur);
    }

    public function destroy($id)
    {
        Utilisateur::findOrFail($id)->delete();
        return response()->json(['message' => 'Utilisateur supprimé']);
    }
}
