<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Soin;

class SoinController extends Controller
{
    public function index()
    {
        return response()->json(Soin::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'nom_soin' => 'required|string',
            'libelle' => 'nullable|string',
            'cout' => 'required|numeric',
        ]);
        $soin = Soin::create($validated);
        return response()->json($soin, 201);
    }

    public function show($id)
    {
        $soin = Soin::findOrFail($id);
        return response()->json($soin);
    }

    public function update(Request $request, $id)
    {
        $soin = Soin::findOrFail($id);
        $validated = $request->validate([
            'nom_soin' => 'string',
            'libelle' => 'string',
            'cout' => 'numeric',
        ]);
        $soin->update($validated);
        return response()->json($soin);
    }

    public function destroy($id)
    {
        Soin::findOrFail($id)->delete();
        return response()->json(['message' => 'Soin supprimé']);
    }
}
