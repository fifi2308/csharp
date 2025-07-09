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
        Schema::create('medecins', function (Blueprint $table) {
    $table->id();
    $table->string('numero_ordre', 10);
    $table->unsignedBigInteger('id_specialite')->nullable();
    $table->unsignedBigInteger('id_utilisateur');
    $table->foreign('id_specialite')->references('id')->on('specialites')->onDelete('set null');
    $table->foreign('id_utilisateur')->references('id')->on('utilisateurs')->onDelete('cascade');
    $table->timestamps();
});

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('medecins');
    }
};
