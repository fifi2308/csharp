<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Patient;

class PatientController extends Controller
{
    public function index()
    {
        return response()->json(Patient::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'groupe_sanguin' => 'required|string|max:3',
            'poids' => 'required|numeric',
            'taille' => 'required|numeric',
            'date_naissance' => 'required|date',
            'id_personne' => 'required|exists:personnes,id',
        ]);
        $patient = Patient::create($validated);
        return response()->json($patient, 201);
    }

    public function show($id)
    {
        $patient = Patient::findOrFail($id);
        return response()->json($patient);
    }

    public function update(Request $request, $id)
    {
        $patient = Patient::findOrFail($id);
        $validated = $request->validate([
            'groupe_sanguin' => 'string|max:3',
            'poids' => 'numeric',
            'taille' => 'numeric',
            'date_naissance' => 'date',
            'id_personne' => 'exists:personnes,id',
        ]);
        $patient->update($validated);
        return response()->json($patient);
    }

    public function destroy($id)
    {
        Patient::findOrFail($id)->delete();
        return response()->json(['message' => 'Patient supprimé']);
    }
}
