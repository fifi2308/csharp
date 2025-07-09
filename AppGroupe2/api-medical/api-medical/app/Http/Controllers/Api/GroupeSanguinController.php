<?php
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\GroupeSanguin;

class GroupeSanguinController extends Controller
{
    public function index()
    {
        return response()->json(GroupeSanguin::all());
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'codegroupesanguin' => 'required|string|max:3',
        ]);
        $gs = GroupeSanguin::create($validated);
        return response()->json($gs, 201);
    }

    public function show($id)
    {
        $gs = GroupeSanguin::findOrFail($id);
        return response()->json($gs);
    }

    public function update(Request $request, $id)
    {
        $gs = GroupeSanguin::findOrFail($id);
        $validated = $request->validate([
            'codegroupesanguin' => 'string|max:3',
        ]);
        $gs->update($validated);
        return response()->json($gs);
    }

    public function destroy($id)
    {
        GroupeSanguin::findOrFail($id)->delete();
        return response()->json(['message' => 'Groupe sanguin supprimé']);
    }
}
