<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('utilisateurs', function (Blueprint $table) {
    $table->id();
    $table->string('identifiant', 20)->unique();
    $table->string('motdepasse', 250);
    $table->boolean('status')->default(true);
    $table->unsignedBigInteger('id_role');
    $table->unsignedBigInteger('id_personne');
    $table->foreign('id_role')->references('id')->on('roles');
    $table->foreign('id_personne')->references('id')->on('personnes')->onDelete('cascade');
    $table->timestamps();
});

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('utilisateurs');
    }
};
